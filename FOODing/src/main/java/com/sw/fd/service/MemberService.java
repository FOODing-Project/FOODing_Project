package com.sw.fd.service;

import com.sw.fd.entity.Member;
import com.sw.fd.repository.MemberRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.time.LocalDate;
import java.util.Optional;

@Service
@Transactional
public class MemberService {

    @Autowired
    private MemberRepository memberRepository;

    public Member saveMember(Member member) {
        member.setMdate(LocalDate.now()); // 가입 날짜를 현재 날짜로 설정
        return memberRepository.save(member);
    }

    public Member login(String username, String password) {
        Optional<Member> memberOpt = memberRepository.findByMid(username);
        if (memberOpt.isPresent()) {
            Member member = memberOpt.get();
            if (member.getMpass().equals(password)) {
                return member; // 로그인 성공
            }
        }
        return null; // 로그인 실패
    }

    public Optional<Member> findMemberById(String mid) {
        return memberRepository.findByMid(mid);
    }

    public void updateMember(Member member) {
        if (memberRepository.existsByMid(member.getMid())) {
            memberRepository.save(member);
        }
    }

    public boolean isMidExists(String mid) {
        return memberRepository.existsByMid(mid);
    }
    public boolean isMnickExists(String mnick) {
        return memberRepository.existsByMnick(mnick);
    }
}
