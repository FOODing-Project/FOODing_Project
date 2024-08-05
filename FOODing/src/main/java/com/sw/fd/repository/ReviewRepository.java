package com.sw.fd.repository;

import com.sw.fd.entity.Review;
import com.sw.fd.entity.Store;
import org.springframework.data.domain.Sort;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface ReviewRepository extends JpaRepository<Review, Integer> {
    Optional<Review> findByRno(int rno);
    List<Review> findByStore_Sno(int sno, Sort sort); // 수정된 부분
    List<Review> findByMember_Mno(int mno);
}