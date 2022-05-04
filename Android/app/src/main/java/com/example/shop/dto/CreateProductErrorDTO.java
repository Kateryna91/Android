package com.example.shop.dto;

import lombok.Data;

@Data
public class CreateProductErrorDTO {
    private String [] name;
    private String [] price;
    private String [] image;
}
