import React, { Component } from 'react';

export class Order extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div>
        <h3>{match.params.orderId}</h3>
      </div>
    );
  }
}