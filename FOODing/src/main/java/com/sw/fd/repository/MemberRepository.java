package com.sw.fd.repository;

import com.sw.fd.entity.Member;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.web.bind.annotation.RequestMapping;

import java.util.Optional;

@Repository
public interface MemberRepository extends JpaRepository<Member, String> {
    Member findByMidAndMpass(String mid, String mpass);


    Optional<Member> findByMid(String mid);

    boolean existsByMid(String mid);
    boolean existsByMnick(String mnick);


}
