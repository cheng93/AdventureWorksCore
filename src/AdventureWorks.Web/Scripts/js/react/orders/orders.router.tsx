import React, { Component } from 'react';
import { Route } from 'react-router-dom';

import { Orders } from './orders/orders.component';
import { Order } from './order/order.component';

export function OrdersRouter({ match }) {
  return (
    <div>
      <Route path={`${match.url}/:orderId`} component={Order} />
      <Route exact path={match.url} component={Orders} />
    </div>
  );
}
