package com.example.HibernateBenchmark.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Entity
@Data
@Table(name = "Tags")
@NoArgsConstructor
@AllArgsConstructor
public class Tag {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "tag_id")
    private Integer tagId;

    @Column(name = "tag_name")
    private String name;

    @ManyToMany(mappedBy = "tags")
    private List<Post> posts;
}
