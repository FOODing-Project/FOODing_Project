package com.sw.fd.entity;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "store_t")
@Data
@AllArgsConstructor
@NoArgsConstructor
public class Store {
    @Id
    private int sno;

    private String sname;
}