package com.example.shop;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.shop.application.HomeApplication;
import com.example.shop.application.JwtSecurityService;
import com.example.shop.dto.AccountResponseDTO;
import com.example.shop.dto.LoginDTO;
import com.example.shop.network.ProductService;
import com.google.android.material.textfield.TextInputEditText;
import com.google.android.material.textfield.TextInputLayout;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends BaseActivity {

    private TextInputLayout textFieldEmail;
    private TextInputEditText txtEmail;

    private TextInputLayout textFieldPassword;
    private TextInputEditText txtPassword;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        textFieldEmail = findViewById(R.id.textFieldEmail);
        txtEmail = findViewById(R.id.txtEmail);

        textFieldPassword = findViewById(R.id.textFieldPassword);
        txtPassword = findViewById(R.id.txtPassword);
    }

    public void handleClick(View view) {
        LoginDTO loginDTO = new LoginDTO();
        loginDTO.setEmail(txtEmail.getText().toString());
        loginDTO.setPassword(txtPassword.getText().toString());

        if (!validationFields(loginDTO))
            return;
        ProductService.getInstance()
                .jsonApi()
                .login(loginDTO)
                .enqueue(new Callback<AccountResponseDTO>() {
                    @Override
                    public void onResponse(Call<AccountResponseDTO> call, Response<AccountResponseDTO> response) {
                        if (response.isSuccessful()) {
                            AccountResponseDTO data = response.body();

                            JwtSecurityService jwtService = (JwtSecurityService) HomeApplication.getInstance();
                            jwtService.saveJwtToken(data.getToken());
//
//                            //tvInfo.setText("response is good");
                            Intent intent = new Intent(LoginActivity.this, ProductsActivity.class);
                            startActivity(intent);
                            finish();
                        } else {
//                            try {
//                                showErrorsServer(response.errorBody().string());
//                            } catch (Exception e) {
//                                System.out.println("------Error response parse body-----");
//                            }
                        }
                    }

                    @Override
                    public void onFailure(Call<AccountResponseDTO> call, Throwable t) {
                        String str = t.toString();
                        int a = 12;
                    }
                });
    }

    private boolean validationFields(LoginDTO loginDTO) {
        textFieldEmail.setError("");
        if (loginDTO.getEmail().equals("")) {
            textFieldEmail.setError("Вкажіть пошту");
            return false;
        }

        textFieldPassword.setError("");
        if (loginDTO.getPassword().equals("")) {
            textFieldPassword.setError("Вкажіть пароль");
            return false;
        }

        return true;
    }
}