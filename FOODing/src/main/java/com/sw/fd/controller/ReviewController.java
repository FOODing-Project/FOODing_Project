package com.sw.fd.controller;

import com.sw.fd.entity.Review;
import com.sw.fd.entity.Store;
import com.sw.fd.service.ReviewService;
import com.sw.fd.service.StoreService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

import java.util.List;

@Controller
public class ReviewController {
    @Autowired
    private ReviewService reviewService;

    @Autowired
    private StoreService storeService;

    @GetMapping("/reviews")
    public String showReviews(@RequestParam("sno") int sno, Model model) {
        List<Review> reviews = reviewService.getReviewsBySno(sno);
        Store store = storeService.getStoreBySno(sno);
        model.addAttribute("reviews", reviews);
        model.addAttribute("store", store);
        return "reviews";
    }

    @PostMapping("/review")
    public String addReview(Review review) {
        review.setMno(1); // mno 임시값
        reviewService.saveReview(review);
        return "redirect:/reviews?sno=" + review.getStore().getSno(); // 리뷰 저장 후 해당 가게의 리뷰 페이지로 리다이렉션
    }

    @GetMapping("/showReviews")
    public String showAllReviews(@RequestParam("sno") int sno, Model model) {
        List<Review> reviews = reviewService.getReviewsBySno(sno);
        model.addAttribute("reviews", reviews);
        return "showReviews";
    }
}