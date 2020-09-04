<template>
  <div class="card ">
    <div class="card-body">
      <!-- <div class="isopen_box" >
        <span class="res-open" v-if="IsOpen.open_now">Open</span>
        <span class="res-close" v-else>Close</span>
      </div> -->
      <h5 href="javascript:;" class="card-title h5 mt-1 mb-3 d-block text-dark">{{index+1}}. {{name}} </h5>
      <p class="card-text text-muted">{{add}}</p>
      <div class="ratting_box">Rating <span class="user_ratings_total">({{rateUser}})</span><span class="rate">{{rateSum}}</span></div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    name: String,
    add: String,
    rateUser: Number,
    rateSum: Number,
    index: Number
  }
}
</script>

<style>
  .isopen_box{
    position: absolute;
    right: -12px;
    top: 2px;
    color: #fff;
    font-size: 11px;
  }
  .isopen_box .res-close{
    background: #D93025;
    padding: 4px 12px;
  }
  .isopen_box .res-open{
    background: #8fda8f;
    padding: 4px 12px;
  }

  .ratting_box{
    text-align: left;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    position: relative;
    line-height: 23px;
  }
  .ratting_box .rate{
    position: absolute;
    right: 0;
    top: 0;
    line-height: 23px;
    padding: 0 4px;
    border-radius: 12px;
    text-align: center;
    background: #fbc31c;
    font-size: 11px;
    color: #fff;
    min-width: 23px;
  }
</style>