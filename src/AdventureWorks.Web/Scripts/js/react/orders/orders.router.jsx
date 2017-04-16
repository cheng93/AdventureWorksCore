import React, { Component } from 'react';
import { Route } from 'react-router-dom';

import { Orders } from './orders/orders.component';
import { Order } from './order/order.component';

export class OrdersRouter extends Component {
  constructor(props) {
    super(props);

  }
  render() {
    return (
      <div>
        <Route path={`${this.props.match.url}/:orderId`} component={Order} />
        <Route exact path={this.props.match.url} component={Orders} />
      </div>
    );
  }
}