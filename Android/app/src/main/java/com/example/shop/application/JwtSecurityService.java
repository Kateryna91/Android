package com.example.shop.application;

public interface JwtSecurityService {
    void saveJwtToken(String token);
    String getToken();
    void deleteToken();
    boolean isAuth();
}
