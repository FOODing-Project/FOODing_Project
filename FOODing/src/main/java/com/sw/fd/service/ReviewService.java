package com.sw.fd.service;

import com.sw.fd.entity.Review;
import com.sw.fd.entity.ReviewTag;
import com.sw.fd.entity.Store;
import com.sw.fd.entity.Tag;
import com.sw.fd.repository.ReviewRepository;
import com.sw.fd.repository.ReviewTagRepository;
import com.sw.fd.repository.StoreRepository;
import com.sw.fd.repository.TagRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.time.LocalDate;
import java.util.List;

@Service
public class ReviewService {

    @Autowired
    private ReviewRepository reviewRepository;

    @Autowired
    private StoreRepository storeRepository;

    @Autowired
    private TagRepository tagRepository;

    @Autowired
    private ReviewTagRepository reviewTagRepository;

    public Review saveReview(Review review) {
        review.setRdate(LocalDate.now());
        return reviewRepository.save(review);
    }

    public Review getReviewByRno(int rno) {
        return (Review) reviewRepository.findByRno(rno).orElse(null);
    }

    public List<Review> getAllReviews() {
        return reviewRepository.findAll();
    }

    public List<Review> getReviewsBySno(int sno) {
        return reviewRepository.findByStore_Sno(sno);
    }


    @Transactional
    public List<Review> getReviewsByMno(int mno) {
        return reviewRepository.findByMember_Mno(mno);
    }

    public void deleteReviewByRno(int rno) {
        reviewRepository.delete(rno);
    }

    public Tag getTagByTno(int tno) {
        return tagRepository.findByTno(tno);
    }

    public void saveReviewTag(ReviewTag reviewTag) {
        reviewTagRepository.save(reviewTag);
    }

}
