<template>
  <div id="app">
    <img src="./assets/images/1.jpg" alt>
    <div class="intro">
      <p class="price red">
        <span>¥</span> 158.00
      </p>
      <p class="desc">
        <span>热卖</span> 茶水分离茶不苦，两头喝不漏水，双层防烫更耐摔，这款高硼硅玻璃杯卖火啦！
      </p>
      <div class="btn-box">
        <el-button type="danger" icon="el-icon-shopping-cart-full">活动大促 抢三重礼</el-button>
      </div>
      <div class="red-box">
        <p>
          <strong>【典雅泡茶杯】双层防烫，茶水分离</strong>
        </p>
        <p>
          <strong>
            吊牌价990元，活动期间
            <span>立减891元</span>，只要99元
          </strong>
        </p>
        <p>
          <strong>用好杯喝好茶，茶水分离茶不苦</strong>
        </p>
        <p>
          <strong>两头喝不漏水，双层隔热不烫手</strong>
        </p>
        <p>
          <strong>下单再送三重好礼，先到先得，全国包邮，送货上门，验货满意后付款</strong>
        </p>
      </div>
      <p class="xinshan">▽请欣赏这款典雅尊贵的茶水分离泡茶杯</p>
    </div>
    <div class="video-box">
      <video src="./assets/images/0.mp4"></video>
    </div>
    <div class="img-box">
      <img src="./assets/images/2.jpg" alt>
      <img src="./assets/images/3.jpg" alt>
      <img src="./assets/images/4.jpg" alt>
      <img src="./assets/images/5.jpg" alt>
      <img src="./assets/images/6.gif" alt>
      <img src="./assets/images/7.jpg" alt>
      <img src="./assets/images/8.gif" alt>
      <img src="./assets/images/9.jpg" alt>
      <img src="./assets/images/10.gif" alt>
      <img src="./assets/images/11.jpg" alt>
      <img src="./assets/images/12.gif" alt>
      <img src="./assets/images/13.jpg" alt>
      <img src="./assets/images/14.gif" alt>
      <img src="./assets/images/15.jpg" alt>
      <img src="./assets/images/16.gif" alt>
      <img src="./assets/images/17.jpg" alt>
      <img src="./assets/images/18.jpg" alt>
      <img src="./assets/images/19.jpg" alt>
      <img src="./assets/images/20.jpg" alt>
      <img src="./assets/images/21.jpg" alt>
      <img src="./assets/images/22.jpg" alt>
      <img src="./assets/images/23.jpg" alt>
      <img src="./assets/images/24.jpg" alt>
      <img src="./assets/images/25.jpg" alt>
      <img src="./assets/images/26.jpg" alt>
      <img src="./assets/images/27.jpg" alt>
      <img src="./assets/images/28.jpg" alt>
      <img src="./assets/images/29.jpg" alt>
      <img src="./assets/images/30.jpg" alt>
      <img src="./assets/images/31.jpg" alt>
      <img src="./assets/images/32.jpg" alt>
      <img src="./assets/images/33.jpg" alt>
      <img src="./assets/images/34.jpg" alt>
      <img src="./assets/images/35.jpg" alt>
      <img src="./assets/images/36.jpg" alt>
      <img src="./assets/images/37.jpg" alt>
      <img src="./assets/images/38.jpg" alt>
      <img src="./assets/images/39.jpg" alt>
      <img src="./assets/images/40.jpg" alt>
      <img src="./assets/images/41.jpg" alt>
      <img src="./assets/images/42.jpg" alt>
      <img src="./assets/images/43.jpg" alt>
      <img src="./assets/images/44.jpg" alt>
      <img src="./assets/images/45.jpg" alt>
      <img src="./assets/images/46.jpg" alt>
      <img src="./assets/images/47.jpg" alt>
      <img src="./assets/images/48.jpg" alt>
      <img src="./assets/images/49.jpg" alt>
      <img src="./assets/images/50.jpg" alt>
    </div>
    <div class="form-title">
      <p>填写订单</p>
    </div>
    <div class="form">
      <el-form ref="form" :model="form" label-width="auto" :rules="rules">
        <!-- <el-radio-group  @change="ddd"> -->
          <el-radio v-model="form.goodsId" name ="goodsRadio" :key="index" v-for="(item,index) in goodsList" :label="item.id">
            {{item.specificationDesc}} 【仅 {{item.price}} 元】
          </el-radio>
        <!-- </el-radio-group> -->
        <div class="info">
          <p class="intro">送大红袍（1罐）+杯套（1个）+备用密封圈（2个）</p>
          <p class="intro">典雅尊贵，双向双层，茶水分离，防爆耐摔</p>
        </div>
        <div class="count">
          <p>
            <span class="red">*</span> 数量
          </p>
          <div class="d-fl">
            <el-input-number
              v-model="form.buyQuantity"
              size="mini"              
              :min="1"
              :max="10"
              label="描述文字"
            ></el-input-number>
            <p class="fl-1">
              商品金额：
              <span class="red">¥ {{getSumPrice}}</span>
            </p>
          </div>
        </div>
        <el-form-item label="姓名" prop="consignee">
          <el-input v-model="form.consignee"></el-input>
        </el-form-item>
        <el-form-item label="手机" prop="phone">
          <el-input v-model="form.phone" type="number"></el-input>
        </el-form-item>
        <el-form-item label="地区" prop="selectArea">
          <el-cascader 
            v-model="form.selectArea"
            :props = "{value:'code',label:'name',children:'children'}"
            :options= "cityList"
            placeholder="请选择活动区域">
          </el-cascader>
        </el-form-item>
        <el-form-item label="付款">
          <el-switch  active-text="验货满意后付款"></el-switch>
        </el-form-item>
        <el-form-item label="详细地址" prop="detailedAddress">
          <el-input v-model="form.detailedAddress"></el-input>
        </el-form-item>
        <el-form-item label="留言" prop="message">
          <el-input v-model="form.message" type="textarea"></el-input>
        </el-form-item>
        <div class="remen">
          <el-checkbox label="记录收货地址，下次购买自动输入" name="type"></el-checkbox>
        </div>
      </el-form>
    </div>
    <div class="footer">
      <el-button type="danger" @click='submitOrder'>提交订单</el-button>
      <p>此页面商品或服务由厦门云盯电子商务有限公司提供</p>
      <p>85494c95.fyeds8.com仅提供技术支持</p>
    </div>
  </div>
</template>
<script>
import cityList from "./assets/js/city_code.js"
import axios from 'axios';
import _ from 'lodash';
console.log(cityList);
export default {
  name: "app",
  data() {
    return {
      form: {        
        goodsId: 2,
        buyQuantity: 1,
        consignee: "",
        phone:"",
        detailedAddress:"",
        message:"",        
        payType:3,
        selectArea: []
      },
      cityList:cityList.cityList,
      goodsList:[
        {id:1,specificationDesc:"超值装：300ml款+400ml款",price:158},
        {id:2,specificationDesc:"特惠装：300ml款1个",price:99},
        {id:3,specificationDesc:"尊享装：400ml款1个",price:108}
      ],
      rules: {
        consignee: [
          {
            required: true,
            message: "请输入姓名",
            trigger: "blur"
          }
        ],
        phone: [
          {
            required: true,
            message: "请输入手机号",
            trigger: "blur"
          }
        ],
        selectArea: [
          {
            required: true,
            message: "请选择所属地区",
            trigger: "change"
          }
        ],
        detailedAddress:[
          {
            required: true,
            message: "请输入详细地址",
            trigger: "change"
          }
        ]
      }
    };
  },
  methods: {
    ddd(a,b){
      console.log(a);
      console.log(b);
    },
    submitOrder(){
      var provinceCode = this.form.selectArea[0];
      var cityCode = this.form.selectArea[1];
      var countyCode = this.form.selectArea[2];

      var provinceModel =  _.find(cityList.cityList,e=>{return e.code == provinceCode});
      var cityModel = _.find(provinceModel.children,e=>{return e.code == cityCode});
      var countyModel = _.find(cityModel.children,e=>{return e.code == countyCode});

      this.form.provinceCode = provinceCode;
      this.form.cityCode = cityCode;
      this.form.countyCode = countyCode;
      this.form.provinceName = provinceModel.name;
      this.form.cityName = cityModel.name;
      this.form.countyName = countyModel.name;

      this.form.orderAmount = this.getSumPrice;

axios.post("http://www.maidongxi.xyz/api/orders/index").then(e=>{
        console.log(e);
      });

      axios.post("http://www.maidongxi.xyz/api/orders/add",this.form).then(e=>{
        console.log(e);
      });
    }
  },
  computed:{
    getSumPrice(){
      var price = _.find(this.goodsList,e=>{return e.id = this.form.goodsId}).price;      
      return price * this.form.buyQuantity
    }
  }
};
</script>

<style lang="scss">
p {
  margin: 0;
}
img {
  width: 100%;
}
html {
  font-size: 13.33333333vw;
}
.red {
  color: #fc0705;
}

body {
  min-width: 320px;
  max-width: 750px;
  margin: 0 auto;
  font-size: 0.32rem;
}

@media (min-width: 750px) {
  html {
    font-size: 92px;
  }
}
.d-fl {
  display: flex;
}
.fl-1 {
  flex: 1;
}
.el-form-item.is-required:not(.is-no-asterisk) > .el-form-item__label:before,
.el-form-item.is-required:not(.is-no-asterisk)
  .el-form-item__label-wrap
  > .el-form-item__label:before {
  color: #fc0705 !important;
}

.el-button {
  display: block;
  width: 100%;
  background-color: #f92064;
  border-color: #f92064;
}

@import url("./assets/css/app.min.css");
</style>
