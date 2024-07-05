package com.sw.fd.controller;

import com.sw.fd.entity.Member;
import com.sw.fd.service.MemberService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

@Controller
public class LoginController {

    @Autowired
    private MemberService memberService;

    @GetMapping("/login")
    public String login() {
        return "login";
    }

    @PostMapping("/login")
    public String login(String id, String password,HttpServletRequest request, Model model) {
        Member member = memberService.findMemberByMidAndMpass(id, password);

        if (member != null) {
            // 로그인 성공
            HttpSession session = request.getSession();
            session.setAttribute("loggedInMember", member); // 세션에 로그인 정보 저장
            model.addAttribute("member", member);
            model.addAttribute("message", "로그인 성공!!");
            return "redirect:/dashboard"; // 대시보드 페이지로 리다이렉트
        } else {
            // 로그인 실패 처리
            model.addAttribute("error", "아이디 또는 비밀번호가 일치하지 않습니다.");
            return "login"; // 다시 로그인 화면으로
        }
    }

    @GetMapping("/dashboard")
    public String showDashboard() {
        return "dashboard"; // 대시보드 페이지로 이동
    }

    @GetMapping("/logout")
    public String logout(HttpServletRequest request) {
        HttpSession session = request.getSession(false);
        if (session != null) {
            session.removeAttribute("loggedInMember");
            session.invalidate(); // 세션 무효화
        }

        return "redirect:/main";
    }
}
