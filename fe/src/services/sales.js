import AxiosClient from '../config/axios'

const token = () => { return localStorage.getItem('tokenid');};

export function getSales(filter = null) {
  let queryString = '';
  if(filter != null){
    if(filter.orderId) {
      queryString = `${queryString}&orderid=${filter.orderId}`;
    }
    if(filter.custName) {
      queryString = `${queryString}&customerName=${filter.custName}`;
    }
    if(filter.since) {
      queryString = `${queryString}&since=${filter.since}`;
    }
    if(filter.until) {
      queryString = `${queryString}&until=${filter.until}`;
    }
  }
  return AxiosClient.get(`sales?q=true${queryString}`, {
    headers: {
      'Authorization': `Bearer ${token()}`
    }});
}

export function getOrder(orderId) {
  return AxiosClient.get(`sales/${orderId}`, {
    headers: {
      'Authorization': `Bearer ${token()}`
    }});
}