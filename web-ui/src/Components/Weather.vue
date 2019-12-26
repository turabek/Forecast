<template>
  <div v-if="weatherInfo.responses" class="weather">
    <table class="table table-striped table-bordered">
      <thead class="thead-light">
        <tr>
          <th scope="col">Date</th>
          <th scope="col">Temperature</th>
          <th scope="col">Humidity</th>
          <th scope="col">Wind Speed</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item,i) in weatherInfo.responses" v-bind:key="i">
          <td>{{item.date|formatDate}}</td>
          <td>{{Math.round(item.temperature)}} &#8451;</td>
          <td>{{Math.round(item.humidity)}} %</td>
          <td>{{item.windSpeed}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import WeatherItem from "./WeatherItem.vue";
import Forecast from "../models/Forecast";

@Component
export default class Weather extends Vue {
  @Prop()
  weatherInfo!: Forecast;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

@media (max-width: 520px) {
.table td, .table th{
    padding: 5px !important;
    padding: 5px !important;
    font-size: small;
  }
}

.table td, .table th{
    vertical-align: middle;
}
  
</style>
