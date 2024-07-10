package com.sw.fd.controller;

import com.sw.fd.entity.Member;
import com.sw.fd.entity.Review;
import com.sw.fd.entity.Store;
import com.sw.fd.service.MemberService;
import com.sw.fd.service.ReviewService;
import com.sw.fd.service.StoreService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

import javax.servlet.http.HttpSession;
import java.util.List;

@Controller
public class ReviewController {
    @Autowired
    private ReviewService reviewService;

    @Autowired
    private StoreService storeService;

    @Autowired
    private MemberService memberService;

    @GetMapping("/review")
    public String showReviews(@RequestParam("sno") int sno, Model model, HttpSession session) {
        // 세션에서 로그인된 회원 ID 가져오기

        Member member =  (Member) session.getAttribute("loggedInMember");

//        // 회원 ID로 회원 정보 조회
//        Member member = memberService.findMemberById(loggedInMemberId);
        if (member == null) {
            // 회원 정보가 없으면 에러 처리
            return "error"; // 적절한 에러 페이지로 리다이렉션
        }

        // 모델에 회원 닉네임 추가
        model.addAttribute("memberNickname", member.getMnick());

        List<Review> reviews = reviewService.getReviewsBySno(sno);
        model.addAttribute("reviews", reviews);
        model.addAttribute("review", new Review()); // 모델에 빈 Review 객체 추가
        model.addAttribute("sno", sno); // sno도 모델에 추가
        return "review";
    }


    @PostMapping("/review")
    public String addReview(@ModelAttribute Review review, @RequestParam("sno") int sno) {


        // sno를 이용하여 Store 객체를 가져오기
        Store store = storeService.getStoreBySno(sno);
        if (store == null) {
            // Store 객체가 없으면 에러 처리
            return "error"; // 적절한 에러 페이지로 리다이렉션
        }

        // 설정자 사용하여 필요한 필드 설정
//        review.setMember(member);
        review.setStore(store); // Store 객체 설정

        // 리뷰를 DB에 저장
        reviewService.saveReview(review);

        // 리뷰 저장 후 해당 가게의 리뷰 페이지로 리다이렉션
        return "redirect:/review?sno=" + sno;
    }



    /*
    @GetMapping("/showReviews")
    public String showAllReviews(@RequestParam("sno") int sno, Model model) {
        List<Review> reviews = reviewService.getReviewsBySno(sno);
        model.addAttribute("reviews", reviews);
        return "showReviews";
    }

    */
}