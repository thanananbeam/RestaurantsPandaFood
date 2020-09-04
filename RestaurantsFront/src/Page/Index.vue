<template>
  <div>
    <div class="container-fluid header-search">
      <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12">
          <h1 class="text">
            Find Restaurants
          </h1>
          <div class="input-group">
            <input type="text" class="form-control" id="search" v-model="textSearch"  >
            <span class="input-group-btn">
              <button class="btn btn-secondary" v-on:click="Restaurants()">Search</button>
            </span>
          </div>
        </div>
      </div>
    </div>
    <div class="">
      <div class="header-result text-center">
        <h1>Restaurants latest data</h1>
        <span>Result : </span><span id="result_data">{{this.dataResponse.result}}</span>
      </div>
    </div>

    <div class="container-lg">
      <span v-if="dataResponse.loadSuccess == 'loadding'">...</span>
      <span v-else-if="dataResponse.loadSuccess == 'error'">Error Request</span>
      <div v-else class="row">
        <div class="col-xs-6 col-sm-4 col-md-4 col-lg-4">

        </div>
      </div>
      <div class="row mt-5">
        <div v-for="(i, index) in dataResponse.item" :key="i.place_id" class="col-xs-6 col-sm-6 col-md-4 col-lg-4 mb-3">
          <CardComponents :name="i.name" :add="i.formatted_address" :rateUser="i.user_ratings_total" :rateSum="i.rating" :index="index" />
        </div>
      </div>

    </div>
  </div>
</template>

<script>
import axios from 'axios';
import CardComponents from '../components/CardComponents.vue'
export default {
  data () {
    return {
      API_ENDPOINT: process.env.VUE_APP_API,
      API_CALLRestaurants: "cores/findrestaurants",
      dataResponse: {
        item: null,
        result: "-",
        status: "",
        loadSuccess: "loadding"
      },
      textSearch: "Bangsue"
    }
  },
  components: {
    CardComponents,
  },
  methods: {
    Restaurants: function () {
      if(this.textSearch.length <= 0){
        alert("Input can't null")
        return false
      }
      this.callService();
    },
    callService: function(){
      axios.post(this.API_ENDPOINT+this.API_CALLRestaurants, {
        "location": this.textSearch
      })
      .then((response) => {
        console.log(response)
        if(response.data.status == "OK"){
          this.dataResponse.item = response.data.results
          this.dataResponse.result = response.data.results.length
          this.dataResponse.status = response.data.status
          this.dataResponse.loadSuccess = "ok"
        }else{
          this.dataResponse.loadSuccess = "error"
        }
        
      }, (error) => {
        console.log(error);
      });
    }
  },
  mounted () {
    console.log()
    this.callService();
  }
}
</script>

<style>
  .header-search {
    background-color: #eee;
    min-height: 80vh;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    padding: 18px;
    color: #4a4a4a;
  }
  .text {
    font-size: 40px;
    transition: 2s all;
    text-align: center;
    margin-bottom: 40px;
  }

  .header-result{
    background: #263238;
    padding: 18px;
    color: white;
  }
  .header-result h1{
    font-size: 18px;
    text-align: center;
    margin: 0 0 6px;
    text-transform: uppercase;
    font-weight: 400;
    letter-spacing: 2px;
  }

</style>