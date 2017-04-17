import React, { Component } from 'react';

function TableBodyRow({ row }) {
  return (
    <tr>
      <td>{row.id}</td>
      <td>{row.customer.name}</td>
      <td>{row.orderDate}</td>
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