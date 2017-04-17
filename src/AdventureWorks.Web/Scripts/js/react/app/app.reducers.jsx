import { combineReducers } from 'redux';

import { ordersReducer } from '../orders/orders/orders.reducer';

export const appReducers = combineReducers({
  orders: ordersReducer
});