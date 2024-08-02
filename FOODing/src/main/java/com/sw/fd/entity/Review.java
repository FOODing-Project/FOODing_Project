package com.sw.fd.entity;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.time.LocalDate;
import java.util.List;

@Entity
@Table(name = "review_t") // 데이터베이스 테이블과 매핑
@Data
@AllArgsConstructor
@NoArgsConstructor
public class Review {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int rno;

    @ManyToOne
    @JoinColumn(name = "mno")
    private Member member;


    @ManyToOne
    @JoinColumn(name = "sno")
    private Store store;

    private int rstar;
    private String rcomm;
    private LocalDate rdate;

    @OneToMany(mappedBy = "review")
    private List<ReviewTag> reviewTags;

    @Transient
    private List<Tag> tags;

    @PrePersist
    protected void onCreate() { rdate = LocalDate.now(); }

}
