import React, { Component } from 'react';

import moment from 'moment';

function TableBodyRow({ row }) {
  let orderDate = moment(row.orderDate).format('DD MMM YYYY');
  return (
    <tr>
      <td>{row.id}</td>
      <td>{row.customer.name}</td>
      <td>{orderDate}</td>
    </tr>
  )
}

export function TableBody({ rows }) {
  const tableRows = rows
    .map(row =>
      <TableBodyRow key={row.id} row={row} />
    );

  return (
    <tbody>
      {tableRows}
    </tbody>
  );

}