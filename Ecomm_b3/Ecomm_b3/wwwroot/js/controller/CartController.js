let TargetCartProducts = [];
let ModifiedCartProduct = [];
var CartController = {
    AddToCart: (id) => {
        let Products = ProductController.GetLocalStorageProduct();  
        $.each(Products, function (index,obj) {
            if (obj.id == id) {
                TargetCartProducts.push(obj);
            }
        })
        console.log(TargetCartProducts.length)
        localStorage.setItem('CartProducts', JSON.stringify(TargetCartProducts));
    },
    DeleteFromCart: (id) => { 
        let CartProducts = CartController.ShowCart();
        $.each(CartProducts, function (index, obj) {
            if (obj.id != id) {
                ModifiedCartProduct.push(obj);
            }
        })
        TargetCartProducts = ModifiedCartProduct;
        console.log(TargetCartProducts.length)
        localStorage.setItem('CartProducts', JSON.stringify(ModifiedCartProduct));
        alert('Product Deleted')
    },
    ShowCart: () => {
        let Products = [];
        if (localStorage.getItem("CartProducts") != undefined && localStorage.getItem("CartProducts") != null && localStorage.getItem("CartProducts") != '') {
            Products = JSON.parse(localStorage.getItem("CartProducts"));
        } 
        console.log(Products)
        return Products;
    }
}