package com.sw.fd.repository;

import com.sw.fd.entity.Member;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface MemberRepository extends JpaRepository<Member, String> {
    Member findByMidAndMpass(String mid, String mpass);


    Optional<Member> findByMid(String mid);

    boolean existsByMid(String mid);
    boolean existsByMnick(String mnick);

}
