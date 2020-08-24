<template>
  <div>
    <!-- 搜索區 -->
    <div class="product-search">
      <input type="text" id="txtsearch" />
      <button>search</button>
    </div>
    <hr />
    <!-- 產品區 -->
    <div class="product-list">
      <ul>
        <li v-for="product in productList" :key="product.id">
          <router-link :to="`/ProductDetail?pid=${product.id}`">
            <img :src="product.productImgUrl" alt />
            <p class="p-price">${{product.price}}</p>
            <p>{{product.productName}}</p>
          </router-link>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      productList: [],
    };
  },
  mounted() {
    this.getProductList();
  },
  methods: {
    getProductList() {
      let thisVue = this;
      this.$http
        .get("https://localhost:44314/api/Products/GetProducts/")
        .then((res) => {
          thisVue.productList = res.data;
        });
    },
  },
};
</script>


<!-- scoped代表此css專門for這邊的vue -->
<style scoped>
* {
  padding: 0;
  margin: 0;
}
.product-search {
  width: 704px;
  height: 44px;
  margin: auto;
}
#txtsearch {
  width: 600px;
  height: 32px;
  border: 6px solid red;
  float: left;
  outline: none;
  padding: 0px 6px;
}
button {
  width: 80px;
  height: 44px;
  border: none 0;
  background-color: red;
  color: white;
  float: left;
  outline: none;
}
hr {
  margin-top: 60px;
  border: 2px solid red;
}
.product-list li {
  width: 260px;
  margin: 60px 0 0 60px;
  list-style: none;
  float: left;
  border: 1px solid #fff;
  padding: 6px;
}
.product-list li:hover {
  border-color: #eee;
  box-shadow: 0 0 6px #ccc;
}
.product-list li img {
  width: 260px;
}
.product-list li p {
  text-align: left;
}
.p-price {
  font-size: 18px;
  font-weight: bold;
  color: tomato;
  margin-bottom: 8px;
}
</style>