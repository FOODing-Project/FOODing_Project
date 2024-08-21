package com.sw.fd.service;

import com.sw.fd.entity.Member;
import com.sw.fd.entity.Pfolder;
import com.sw.fd.entity.Pick;
import com.sw.fd.entity.Store;
import com.sw.fd.repository.MemberRepository;
import com.sw.fd.repository.PfolderRepository;
import com.sw.fd.repository.PickRepository;
import com.sw.fd.repository.StoreRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;

@Service
public class PickService {

    @Autowired
    private PickRepository pickRepository;

    @Autowired
    private MemberRepository memberRepository;

    @Autowired
    private StoreRepository storeRepository;

    @Autowired
    public PfolderRepository pfolderRepository;


    public boolean togglePick(int mno, int sno, int pfno) {
        Member member = memberRepository.findByMno(mno).orElseThrow(() -> new RuntimeException("로그인 정보를 불러오는 데 실패했습니다."));;
        Store store = storeRepository.findBySno(sno).orElseThrow(() -> new RuntimeException("가게 정보를 불러오는 데 실패했습니다."));;
        Pfolder pfolder = pfolderRepository.findByPfno(pfno).orElseThrow(() -> new RuntimeException("폴더 정보를 불러오는 데 실패했습니다."));;

        Pick existingPick = pickRepository.findByMemberAndStore(member, store);
        if (existingPick != null) {
            pickRepository.delete(existingPick);
            return false;
        } else {
            Pick newPick = new Pick(member, store, pfolder);
            pickRepository.save(newPick);
            return true;
        }
    }

    public boolean isPicked(int mno, int sno) {
        Member member = memberRepository.findByMno(mno).orElseThrow(() -> new RuntimeException("로그인 정보를 불러오는 데 실패했습니다."));;
        Store store = storeRepository.findBySno(sno).orElseThrow(() -> new RuntimeException("가게 정보를 불러오는 데 실패했습니다."));;

        Pick existingPick = pickRepository.findByMemberAndStore(member, store);
        return existingPick != null;
    }

    public List<Pick> getPicksByMno(int mno) {
        return pickRepository.findByMemberMno(mno);
    }

    public List<Pick> getPicksByPfolder(Pfolder pfolder) {
        return pickRepository.findByPfolder(pfolder);
    }

    public Pick findPickByMemberAndStore(Member member, Store store) {
        return pickRepository.findByMemberAndStore(member, store);
    }

    @Transactional
    public Pick savePick(Pick pick) {
        return pickRepository.save(pick);
    }
}
