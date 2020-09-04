import Vue from 'vue'
import App from './App.vue'
import axios from 'axios';

import jQuery from 'jquery'
import bootstrap from 'bootstrap'

import 'bootstrap/dist/css/bootstrap.css'
global.jQuery = jQuery
global .$ = jQuery


new Vue({
  render: h => h(App),
}).$mount('#app')
