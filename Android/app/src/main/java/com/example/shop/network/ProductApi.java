package com.example.shop.network;

import com.example.shop.dto.AccountResponseDTO;
import com.example.shop.dto.CreateProductDTO;
import com.example.shop.dto.CreateProductResultDTO;
import com.example.shop.dto.LoginDTO;
import com.example.shop.dto.ProductDTO;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface ProductApi {
    @POST("/api/products/create")
    public Call<CreateProductResultDTO> create(@Body CreateProductDTO model);
    @GET("/api/products/list")
    public Call<List<ProductDTO>> list();
    @POST("/api/account/login")
    public Call<AccountResponseDTO> login(@Body LoginDTO model);
}
