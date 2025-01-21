let TargetCartProducts = []; 
let ModifiedCartProduct = []; 
var CartController = {
    AddToCart: (id) => {
        TargetCartProducts = CartController.ShowCart();
        ProductController.SingleProduct(id, function (response) {
            TargetCartProducts.push(response);
            console.log(TargetCartProducts.length)
            localStorage.setItem('CartProducts', JSON.stringify(TargetCartProducts));
            CartController.AppendToCartView(response);
        });  
        
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
        //CartController.ShowPartialCartView();
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
    AppendToCartView: (obj) => {
        let isexists = false;
        $('body').find('.clsCartRow').each(function () {
            if (obj.id == parseInt($(this).attr('id').split('_')[2])) {
                isexists = true;
            }
        })
        console.log('-------------------------------')
        console.log(obj.id)
        console.log(isexists)
        console.log('--------------end-----------------')
        if (!isexists) {
            $('#tblPartialCartProduct').append(`<tr id='cart_tr_${obj.id}' class='clsCartRow'><td><img style='width:40px' src="${obj.thumbnail}"></td><td>${obj.title}</td><td>${obj.price}</td><td><span class='clsPartialCount' id='cart_count_${obj.id}'>1</span></td><td><a onclick='CartController.DeleteFromCart(${obj.id});$($(this).parent().parent()).remove()'>Delete</a></td></tr>`)
            //trs = trs + `<tr id='cart_tr_${obj.id}' class='clsCartRow'><td><img style='width:40px' src="${obj.thumbnail}"></td><td>${obj.title}</td><td>${obj.price}</td><td><span class='clsPartialCount' id='cart_count_${obj.id}'>1</span></td><td><a onclick='CartController.DeleteFromCart(${obj.id});$($(this).parent().parent()).remove()'>Delete</a></td></tr>`;
        }
        else {
            $('#cart_count_' + obj.id).html(parseInt($('#cart_count_' + obj.id).html()) + 1)
        } 
        $('#dvCart').animate({ right: 0 });

    },
    ShowPartialCartView: () => { 
        $("#tblPartialCartProduct").find("tr:gt(0)").remove();
        if ($('#tblPartialCartProduct').find('tr').length == 1) {
            let products = CartController.ShowCart();
            $.each(products, function (index, obj) {
                let isexists = false;
                $('body').find('.clsCartRow').each(function () {
                    if (obj.id == parseInt($(this).attr('id').split('_')[2])) {
                        isexists = true;
                    }
                })
                console.log('-------------------------------')
                console.log(obj.id)
                console.log(isexists)
                console.log('--------------end-----------------')
                if (!isexists) {
                    $('#tblPartialCartProduct').append(`<tr id='cart_tr_${obj.id}' class='clsCartRow'><td><img style='width:40px' src="${obj.thumbnail}"></td><td>${obj.title}</td><td>${obj.price}</td><td><span class='clsPartialCount' id='cart_count_${obj.id}'>1</span></td><td><a onclick='CartController.DeleteFromCart(${obj.id});$($(this).parent().parent()).remove()'>Delete</a></td></tr>`)
                    //trs = trs + `<tr id='cart_tr_${obj.id}' class='clsCartRow'><td><img style='width:40px' src="${obj.thumbnail}"></td><td>${obj.title}</td><td>${obj.price}</td><td><span class='clsPartialCount' id='cart_count_${obj.id}'>1</span></td><td><a onclick='CartController.DeleteFromCart(${obj.id});$($(this).parent().parent()).remove()'>Delete</a></td></tr>`;
                }
                else {
                    $('#cart_count_' + obj.id).html(parseInt($('#cart_count_' + obj.id).html()) + 1)
                } 

            })
        }
        $('#dvCart').animate({ right: 0 });
       
    }
}