package com.sw.fd.controller;

import com.sw.fd.entity.Member;
import com.sw.fd.entity.Pfolder;
import com.sw.fd.entity.Pick;
import com.sw.fd.service.PfolderService;
import com.sw.fd.service.PickService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.env.SystemEnvironmentPropertySource;
import org.springframework.security.core.parameters.P;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

import javax.persistence.ManyToOne;
import javax.servlet.http.HttpSession;
import java.util.List;

@Controller
public class PickController {

    @Autowired
    private PickService pickService;

    @Autowired
    private PfolderService pfolderService;

    @GetMapping("/pickList")
    public String pickList(HttpSession session, Model model) {
        Member loggedInMember = (Member) session.getAttribute("loggedInMember");
        if (loggedInMember == null) {
            return "redirect:/login";
        }

        List<Pfolder> pfolderList = pfolderService.getPfoldersByMno(loggedInMember.getMno());
        List<Pick> pickList = pickService.getPicksByMno(loggedInMember.getMno());

        model.addAttribute("pickList", pickList);
        model.addAttribute("pfolderList", pfolderList);

        return "pickPage";
    }


    @PostMapping("/pick")
    @ResponseBody
    public String pickStore(@RequestParam("sno") int sno, @RequestParam(value = "pfno", defaultValue = "1") int pfno, HttpSession session) {
        Member loggedInMember = (Member) session.getAttribute("loggedInMember");
        if (loggedInMember == null) {
            return "error"; // 로그인되지 않은 상태에서 예외 처리
        }

        int mno = loggedInMember.getMno();
        boolean isPicked = pickService.togglePick(mno, sno, pfno);
        return isPicked ? "picked" : "unpicked";
    }

    @PostMapping("/checkPick")
    @ResponseBody
    public String checkPick(@RequestParam("sno") int sno, HttpSession session) {
        Member loggedInMember = (Member) session.getAttribute("loggedInMember");
        if (loggedInMember == null) {
            return "unpicked"; // 로그인되지 않은 상태에서 예외 처리
        }

        int mno = loggedInMember.getMno();
        boolean isPicked = pickService.isPicked(mno, sno);
        return isPicked ? "picked" : "unpicked";
    }

    /*@PostMapping("/removePick")
    @ResponseBody
    public String removePick(@RequestParam("pno") int pno) {
        try {
            pickService.removePickByPno(pno);
            return "success";
        } catch (Exception e) {
            return "error";
        }
        return "redirect:/pickList";
    }*/

    @PostMapping("/createFolder")
    public String createFolder(@RequestParam("pfname") String pfname, HttpSession session) {
        Member loggedInMember = (Member) session.getAttribute("loggedInMember");


        Pfolder pfolder = new Pfolder();
        pfolder.setPfname(pfname);
        pfolder.setMember(loggedInMember);

        pfolderService.savePfolder(pfolder);

        return "redirect:/pickList";
    }

    @PostMapping("/deleteFolder")
    public String deleteFolder(@RequestParam(value = "selectedFolders", required = false) List<Integer> selectedFolders, HttpSession session) {
        if (selectedFolders != null && !selectedFolders.isEmpty()) {
            for (Integer pfno : selectedFolders) {
                pfolderService.deletePfolderByPfno(pfno);
            }
        }
        return "redirect:/pickList";
    }

    @PostMapping("/updateFolderName")
    @ResponseBody
    public String updateFolderName(@RequestParam("pfno") Integer pfno, @RequestParam("pfname") String pfname, HttpSession session) {
        Member loggedInMember = (Member) session.getAttribute("loggedInMember");
        Pfolder pfolder = pfolderService.findByPfno(pfno);

        pfolder.setPfname(pfname);
        pfolderService.savePfolder(pfolder);
        return "success";
/*
        return "redirect:/pickList";*/
    }
}
