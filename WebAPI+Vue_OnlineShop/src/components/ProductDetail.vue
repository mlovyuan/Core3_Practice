<template>
  <div class="product-page">
    <!-- 該項商品資訊 -->
    <div class="product-info">
      <div class="product-info-left">
        <img :src="product.productImgUrl" alt  style="width:300px"/>
      </div>
      <div class="product-info-right">
        <p class="p-name">{{product.productName}}</p>
        <p class="p-price">${{product.price}}</p>
        <p class="p-quantity">
          <span class="deduct" @click="reductQuantity">-</span>
          <!-- 數據單向綁定時 -->
          <!-- <input type="text" :value="quantity" @change="changeQuantity()" /> -->
          <!-- 數據雙向綁定時 -->
          <input type="text" v-model="quantity" />
          <span class="add" @click="addQuantity">+</span>
        </p>
        <p class="p-AddToCart">
          <button>放入購物車</button>
        </p>
      </div>
    </div>
    <hr style="margin-buttom:20px" />
    <!-- 商品詳情 -->
    <div class="product-detail">
      <img :src="product.productDetailImgUrl" alt="">
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      quantity: 1,
      product:{}
    };
  },
  mounted() {
    // 取得上個頁面中放置在連結上的商品id
    let pid = this.$route.query.pid;
  },
  methods: {
    addQuantity() {
      this.quantity++;
    },
    reductQuantity() {
      if (this.quantity > 1) {
        this.quantity--;
      }
    },
    getProductbyId(){
      let thisVue = this;
      this.$http.get("").then((res) => {
        this.product = res.data;
      })
    }
    /*
    changeQuantity() {
      
      // 得到change後的數量
      let newNum = event.target.value;

      // 單向綁定時使用的方式
      if(!isNaN(newNum) && newNum > 0){
        this.quantity = newNum;
      }
      else{
        event.target.value = this.quantity;
      }
      
    },*/
  },
  watch: {
    // 監聽quantity這個變量
    // 等同quantity:function(){}
    quantity(newValue, oldValue) {
      if (isNaN(newValue) || newValue < 1) {
        this.quantity = oldValue;
      }
    },
  },
};
</script>

<style>
.product-page {
  width: 750px;
  margin: auto;
}
.product-info{
  height: 400px;
}
.product-info-left {
  float: left;
}
.product-info-right {
  float: left;
  margin-left: 60px;
}
.product-info-right p {
  margin-bottom: 60px;
  text-align: left;
}
.product-info-right .p-name {
  font-size: 18px;
  font-weight: bold;
}
.product-info-right .p-price {
  font-size: 18px;
  font-weight: bold;
  color: red;
}
.product-info-right .p-AddToCart button {
  width: 210px;
  height: 50px;
  background-color: rgb(252, 92, 0);
  border: 0 none;
  border-radius: 3px;
  color: #fff;
  font-size: 16px;
  font-weight: bold;
  cursor: pointer;
}
.product-info-right .p-quantity input {
  height: 36px;
  border: 1px solid #ccc;
  border-left: 0 none;
  border-right: 0 none;
  width: 66px;
  outline: none;
  text-align: center;
  float: left;
}
.p-quantity {
  height: 36px;
  width: 300px;
}
.p-quantity span {
  display: inline-block;
  height: 36px;
  width: 36px;
  border: 1px solid #ccc;
  text-align: center;
  cursor: pointer;
  line-height: 36px;
  float: left;
}
.deduct {
  border-radius: 3px 0 0 3px;
}
.add {
  border-radius: 0 3px 3px 0;
}
</style>
