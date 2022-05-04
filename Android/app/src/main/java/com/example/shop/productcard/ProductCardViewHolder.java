package com.example.shop.productcard;

import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import com.example.shop.R;

public class ProductCardViewHolder extends RecyclerView.ViewHolder {
    private View view;
    public ImageView producimg;
    public TextView productname;

    public ProductCardViewHolder(@NonNull View itemView) {
        super(itemView);
        this.view= itemView;
        producimg=itemView.findViewById(R.id.producimg);
        productname=itemView.findViewById(R.id.productname);
    }

    public View getView() {
        return view;
    }
}
