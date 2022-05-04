package com.example.shop.network;

import com.example.shop.constants.Urls;
import com.example.shop.network.interceptors.JWTInterceptor;

import java.util.concurrent.TimeUnit;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class ProductService {
    private static ProductService instance;
    private Retrofit retrofit;

    private ProductService() {
        OkHttpClient okHttpClient = new OkHttpClient.Builder()
                .connectTimeout(20, TimeUnit.SECONDS)
                .writeTimeout(20, TimeUnit.SECONDS)
                .readTimeout(30, TimeUnit.SECONDS)
                .addInterceptor(new JWTInterceptor())
                .build();
        retrofit = new Retrofit.Builder()
                .client(okHttpClient)
                .baseUrl(Urls.BASE)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
    }

    public static ProductService getInstance() {
        if(instance==null)
            instance=new ProductService();
        return instance;
    }

    public ProductApi jsonApi() {
        return retrofit.create(ProductApi.class);
    }


}