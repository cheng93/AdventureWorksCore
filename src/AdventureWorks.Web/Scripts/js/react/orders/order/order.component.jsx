import React, { Component } from 'react';

export function Order({match}) {
  return (
    <div>
      <h3>{match.params.orderId}</h3>
    </div>
  );
}