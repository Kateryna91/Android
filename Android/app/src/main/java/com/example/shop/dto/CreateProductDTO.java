package com.example.shop.dto;

import lombok.Data;

@Data
public class CreateProductDTO {
    private String name;
    private String price;
    private String description;
    private String image;

    public CreateProductDTO() {
    }

    public CreateProductDTO(String name, String price, String description, String image) {
        this.name = name;
        this.price = price;
        this.description = description;
        this.image = image;
    }
}
