package com.example.shop.productcard;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;
import com.example.shop.application.HomeApplication;
import com.example.shop.constants.Urls;
import com.example.shop.dto.ProductDTO;

import java.util.List;
import com.example.shop.R;

public class ProductsAdapter extends RecyclerView.Adapter<ProductCardViewHolder> {
    List<ProductDTO> products;

    public ProductsAdapter(List<ProductDTO> products) {
        this.products = products;
    }

    @NonNull
    @Override
    public ProductCardViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View layoutView = LayoutInflater
                .from(parent.getContext())
                .inflate(R.layout.card_product, parent, false);
        return new ProductCardViewHolder(layoutView);
    }

    @Override
    public void onBindViewHolder(@NonNull ProductCardViewHolder holder, int position) {
        if(products!=null && position<products.size()) {
            ProductDTO product = products.get(position);
            holder.productname.setText(product.getName());
            String url = Urls.BASE+"/images/"+product.getImage();
            Glide.with(HomeApplication.getInstance())
                    .load(url)
                    .apply(new RequestOptions().override(600,300))
                    .into(holder.producimg);
        }

    }

    @Override
    public int getItemCount() {
        return products.size();
    }
}
