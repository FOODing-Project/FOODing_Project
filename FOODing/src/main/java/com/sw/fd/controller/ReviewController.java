package com.sw.fd.controller;

import com.sw.fd.entity.*;
import com.sw.fd.service.MemberService;
import com.sw.fd.service.ReviewService;
import com.sw.fd.service.StoreService;
import com.sw.fd.service.TagService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

import javax.servlet.http.HttpSession;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.zip.CheckedOutputStream;

@Controller
public class ReviewController {

    @Autowired
    private ReviewService reviewService;

    @Autowired
    private StoreService storeService;

    @Autowired
    private TagService tagService;

    @Autowired
    private MemberService memberService;

    @GetMapping("/review")
    public String review(@RequestParam("sno") int sno, Model model) {
        List<Review> reviews = reviewService.getReviewsBySno(sno);
        reviews.sort(Comparator.comparing(Review::getRdate).reversed());
        Store store = storeService.getStoreById(sno);
        List<Tag> allTags = tagService.getAllTags();

        // 작성된 리뷰에 태그를 띄워줌
        for (Review review : reviews) {
            List<Tag> tags = tagService.getTagsByRno(review.getRno());
            review.setTags(tags);
        }

        model.addAttribute("reviews", reviews);
        model.addAttribute("review", new Review()); // 모델에 빈 Review 객체 추가
        model.addAttribute("sno", sno);
        model.addAttribute("store", store);
        model.addAttribute("isEmpty", reviews.isEmpty()); // 작성된 리뷰가 존재하는지 확인
        model.addAttribute("tags", allTags);
        return "review";
    }

    @PostMapping("/review")
    public String addReview(@ModelAttribute Review review, @RequestParam("sno") int sno, @RequestParam("tnos") List<Integer> tnos, HttpSession session) {
        Member member = (Member) session.getAttribute("loggedInMember");

        if (member == null) {
            // 회원 정보가 없으면 에러 처리
            return "error"; // 적절한 에러 페이지로 리다이렉션
        }

        // sno를 이용하여 Store 객체를 가져오기
        Store store = storeService.getStoreById(sno);
        if (store == null) {
            // Store 객체가 없으면 에러 처리
            return "error"; // 적절한 에러 페이지로 리다이렉션
        }

        // 설정자 사용하여 필요한 필드 설정
        review.setMember(member);
        review.setStore(store); // Store 객체 설정

        // 리뷰를 DB에 저장
        Review savedReview = reviewService.saveReview(review);

        // 선택된 태그를 ReviewTag로 변환하여 저장
        for (Integer tno : tnos) {
            Tag tag = tagService.getTagByTno(tno);
            ReviewTag reviewTag = new ReviewTag();
            reviewTag.setReview(savedReview);
            reviewTag.setTag(tag);
            tagService.saveReviewTag(reviewTag); // 각 태그를 저장
        }

        // 리뷰 저장 후 해당 가게의 리뷰 페이지로 리다이렉션
        return "redirect:/storeDetail?sno=" + sno; // 여기가 storeDetail로 가야함
    }

    @GetMapping("/myReviews")
    public String showMyReviews(Model model, HttpSession session) {
        Member loggedInMember = (Member) session.getAttribute("loggedInMember");

        if (loggedInMember == null) {
            // 로그인되지 않은 상태에서 접근 시 예외 처리 또는 로그인 페이지로 리다이렉트
            return "redirect:/login";
        }

        // 로그인한 회원의 mno를 가져와서 해당 회원이 작성한 리뷰들을 가져옴
        int mno = loggedInMember.getMno();
        List<Review> reviews = reviewService.getReviewsByMno(mno);
        model.addAttribute("reviews", reviews);

        return "myReviews"; // 내가 쓴 리뷰 목록을 보여주는 JSP 파일명
    }

    @PostMapping("/review/delete")
    public String deleteReview(@RequestParam("rno") int rno, HttpSession session) {
        Member loggedInMember = (Member) session.getAttribute("loggedInMember");

        Review review = reviewService.getReviewByRno(rno);

        // 리뷰 삭제
        reviewService.deleteReviewByRno(rno);

        // 리뷰 삭제 후 해당 가게의 리뷰 페이지로 리다이렉션
        return "redirect:/storeDetail?sno=" + review.getStore().getSno();
    }

    // 수정 폼을 표시하는 GET 요청
    @GetMapping("/review/edit")
    public String editReviewForm(@RequestParam("rno") int rno, Model model, HttpSession session) {
        Member loggedInMember = (Member) session.getAttribute("loggedInMember");

        if (loggedInMember == null) {
            System.out.println("로그인된 회원 정보가 없습니다.");
            return "error";
        }

        Review review = reviewService.getReviewByRno(rno);
        if (review == null || review.getMember().getMno() != loggedInMember.getMno()) {
            System.out.println("리뷰가 없거나 작성자가 아닙니다. 리뷰 번호: " + rno);
            return "error";
        }

        List<Tag> tags = tagService.getAllTags(); // 태그 리스트를 가져옴
        model.addAttribute("tags", tags);
        model.addAttribute("review", review);
        return "editReview"; // editReview.jsp 파일로 반환
    }

    @PostMapping("/review/update")
    @ResponseBody
    public Map<String, String> updateReview(@ModelAttribute Review review, @RequestParam("tnos") List<Integer> tnos, HttpSession session) {
        Map<String, String> response = new HashMap<>();
        Member loggedInMember = (Member) session.getAttribute("loggedInMember");

        if (loggedInMember == null) {
            response.put("status", "error");
            response.put("message", "로그인된 회원 정보가 없습니다.");
            return response;
        }

        Review existingReview = reviewService.getReviewByRno(review.getRno());
        if (existingReview == null || existingReview.getMember().getMno() != loggedInMember.getMno()) {
            response.put("status", "error");
            response.put("message", "리뷰가 없거나 작성자가 아닙니다.");
            return response;
        }

        try {
            existingReview.setRstar(review.getRstar());
            existingReview.setRcomm(review.getRcomm());

            reviewService.deleteReviewTags(existingReview);

            for (Integer tno : tnos) {
                Tag tag = tagService.getTagByTno(tno);
                ReviewTag reviewTag = new ReviewTag();
                reviewTag.setReview(existingReview);
                reviewTag.setTag(tag);
                tagService.saveReviewTag(reviewTag);
            }

            reviewService.saveReview(existingReview);
        } catch (Exception e) {
            e.printStackTrace();
            response.put("status", "error");
            response.put("message", "리뷰 업데이트 중 오류 발생: " + e.getMessage());
            return response;
        }

        response.put("status", "success");
        response.put("message", "리뷰가 성공적으로 업데이트되었습니다.");
        return response;
    }

}
