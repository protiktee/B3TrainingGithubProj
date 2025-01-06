var ProductController = { 
    GetProducts: () => {
        $.get("https://dummyjson.com/products", function (response) {

            if (response.products.length > 0) {
                localStorage.setItem("Products", JSON.stringify(response.products));
            }

            let data = '';
            $.each(response.products, function (index, obj) {
                data = data + `
                     <div class="col">
                        <div class="card" style="width: 18rem;">
                                <img class="card-img-top" src="${obj.thumbnail}" alt="Card image cap">
                            <div class="card-body">
                                    <h5 class="card-title">${obj.title}</h5>
                                    <p class="card-text" id="price">${obj.price}</p>
                                    <a href="#" class="btn btn-primary" onclick='CartController.AddToCart(${obj.id})'>Add to cart</a>
                            </div>
                        </div>
                    </div>
                `;
            })
            $('#dvProducts').append(data);
        }) 
    },
    GetLocalStorageProduct: () => {
        let Products = [];
        if (localStorage.getItem("Products") != undefined && localStorage.getItem("Products") != null && localStorage.getItem("Products") != '') {
            Products = JSON.parse(localStorage.getItem("Products"));
        }
        else {
            $.get("https://dummyjson.com/products", function (response) {
                if (response.products.length > 0) {
                    localStorage.setItem("Products", JSON.stringify(response.products));
                    $.each(response.products, function (index, obj) {
                        Products.push(obj);
                    })
                }
            })
        }
        return Products;
    }
} 