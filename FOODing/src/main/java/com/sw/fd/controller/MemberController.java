package com.sw.fd.controller;

import com.sw.fd.entity.Member;
import com.sw.fd.service.MemberService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.Optional;

@Controller
public class MemberController {

    @Autowired
    private MemberService memberService;

    @GetMapping("/registerSelect")
    public String selectRegister() {
        return "registerSelect";
    }

    @GetMapping("/register/user")
    public String showUserForm(Model model) {
        Member member = new Member();
        member.setMtype(0); // 손님 (일반회원)으로 설정
        model.addAttribute("member", member);
        model.addAttribute("memberType", "손님");
        return "registerUser";
    }

    @GetMapping("/register/owner")
    public String showOwnerForm(Model model) {
        Member member = new Member();
        member.setMtype(1); // 사장님으로 설정
        model.addAttribute("member", member);
        model.addAttribute("memberType", "사장님");
        return "registerOwner";
    }

    @PostMapping("/register/user")
    public String registerUser(@Valid @ModelAttribute("member") Member member, BindingResult bindingResult, Model model) {
        if (bindingResult.hasErrors()) {
            model.addAttribute("memberType", "손님");
            return "registerUser";
        }
        memberService.saveMember(member);
        model.addAttribute("message", "일반 회원 가입 성공! 환영합니다!");
        return "login";
    }

    @PostMapping("/register/owner")
    public String registerOwner(@Valid @ModelAttribute("member") Member member, BindingResult bindingResult, Model model) {
        if (bindingResult.hasErrors()) {
            model.addAttribute("memberType", "사장님");
            return "registerOwner";
        }
        memberService.saveMember(member);
        model.addAttribute("message", "사장님 회원 가입 성공! 환영합니다!");
        return "login";
    }

    // 회원 정보 조회
    @GetMapping("/member/view")
    public String viewMember(@RequestParam("mid") String mid, Model model) {
        Optional<Member> member = memberService.findMemberById(mid);
        if (member.isPresent()) {
            model.addAttribute("member", member.get());
            return "viewMember";
        } else {
            model.addAttribute("error", "회원 정보를 찾을 수 없습니다.");
            return "error";
        }
    }

    // 회원 정보 수정 폼 보여주기
    @GetMapping("/member/edit/{mid}")
    public String showEditForm(@PathVariable("mid") String mid, Model model) {
        Optional<Member> memberOpt = memberService.findMemberById(mid);
        if (memberOpt.isPresent()) {
            model.addAttribute("member", memberOpt.get());
            return "editMember"; // 수정 폼으로 이동
        } else {
            return "redirect:/member/view";
        }
    }

    // 회원 정보 수정 처리
    @PostMapping("/member/edit")
    public String updateMember(@ModelAttribute("member") @Valid Member member,
                               BindingResult bindingResult, Model model) {
        if (bindingResult.hasErrors()) {
            return "editMember"; // 입력 폼으로 다시 이동
        }

        Optional<Member> existingMemberOpt = memberService.findMemberById(member.getMid());
        if (existingMemberOpt.isPresent()) {
            Member existingMember = existingMemberOpt.get();
            member.setMdate(existingMember.getMdate()); // 기존 `mdate` 값을 유지
        }

        memberService.updateMember(member); // 회원 정보 업데이트
        model.addAttribute("message", "회원 정보가 성공적으로 수정되었습니다.");
        return "redirect:/dashboard";
    }
}
