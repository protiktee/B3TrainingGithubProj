let TargetCartProducts = [];
let TargetCartProductsCount = [];
let ModifiedCartProduct = [];

var CartController = {
    AddToCart: (id) => {
        let Products = ProductController.GetLocalStorageProduct();  
        $.each(Products, function (index,obj) {
            if (obj.id == id) {  
                TargetCartProducts.push(obj);
                var CartProductCount = {
                    productid: obj.id,
                    Count:1
                }
                TargetCartProductsCount.push(CartProductCount)
            }
        })
        console.log(TargetCartProducts.length)
        localStorage.setItem('CartProducts', JSON.stringify(TargetCartProducts));
        CartController.ShowPartialCartView();
    },
    DeleteFromCart: (id) => { 
        let CartProducts = CartController.ShowCart();
        ModifiedCartProduct = [];
        $.each(CartProducts, function (index, obj) {
            if (obj.id != id) {
                ModifiedCartProduct.push(obj);
            }
        })
        TargetCartProducts = ModifiedCartProduct;
        console.log(TargetCartProducts.length)
        localStorage.setItem('CartProducts', JSON.stringify(ModifiedCartProduct));
        CartController.ShowPartialCartView();
        alert('Product Deleted')
    },
    ShowCart: () => {
        let Products = [];
        if (localStorage.getItem("CartProducts") != undefined && localStorage.getItem("CartProducts") != null && localStorage.getItem("CartProducts") != '') {
            Products = JSON.parse(localStorage.getItem("CartProducts"));
        } 
        console.log(Products)
        return Products;
    },
    ShowPartialCartView: () => {
        let Products = CartController.ShowCart();
        $('#tblPartialCartProduct').html('');
        let trs = ` <tr>
                <th>Image</th>
                <th>Name</th>
                <th>Price</th>
                <th>Delete</th>
            </tr>`;
        $.each(Products, function (index, obj) {
            trs = trs + `<tr><td><img style='width:40px' src="${obj.thumbnail}"></td><td>${obj.title}</td><td>${obj.price}</td><td><a onclick='CartController.DeleteFromCart(${obj.id});$($(this).parent().parent()).remove()'>Delete</a></td></tr>`;
        })
        $('#tblPartialCartProduct').html(trs);

        $('#dvCart').animate({ right: 0 });
    }
}