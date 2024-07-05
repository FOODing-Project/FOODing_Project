package com.sw.fd.controller;

import com.sw.fd.entity.Review;
import com.sw.fd.service.ReviewService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.List;

@Controller
public class ReviewController {
    @Autowired
    private ReviewService reviewService;

    @GetMapping("/review")
    public String selectReview(Model model) {
        model.addAttribute("review", new Review());
        return "review";
    }

    @PostMapping("/review")
    public String addReview(Review review) {
        review.setMno(1); // mno 임시값
        review.setSno(1); // sno 임시값

        reviewService.saveReview(review);
        return "redirect:/showReviews"; // 리뷰 저장 후 showReviews 페이지로 리다이렉션
    }

    @GetMapping("/showReviews")
    public String showReviews(Model model) {
        List<Review> reviews = reviewService.getAllReviews();
        model.addAttribute("reviews", reviews);
        return "showReviews";
    }

}
