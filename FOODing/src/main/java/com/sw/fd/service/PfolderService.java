package com.sw.fd.service;

import com.sw.fd.entity.Pfolder;
import com.sw.fd.repository.MemberRepository;
import com.sw.fd.repository.PfolderRepository;
import com.sw.fd.repository.PickRepository;
import com.sw.fd.repository.StoreRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PfolderService {

    @Autowired
    private PickRepository pickRepository;

    @Autowired
    private MemberRepository memberRepository;

    @Autowired
    private StoreRepository storeRepository;

    @Autowired
    public PfolderRepository pfolderRepository;

    public List<Pfolder> getPfoldersByMno(int mno) {
        return pfolderRepository.findByMemberMno(mno);
    }
}
