package com.example.shop.dto;

import lombok.Data;

@Data
public class ValidationCreateProductDTO {
    private int status;
    private String title;
    private CreateProductErrorDTO errors;
}

