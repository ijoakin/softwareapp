/* eslint-disable jsx-a11y/anchor-is-valid */
import React from "react";

export interface PaginationProps {
  itemsPerPage: number;
  totalItems: number;
  paginate: any;
}

const PaginationComponent = (props: PaginationProps) => {
  const pageNumbers: number[] = [];

  for (let i = 1; i <= Math.ceil(props.totalItems / props.itemsPerPage); i++) {
    pageNumbers.push(i);
  }

  return (
    <nav className="pagination">
      {pageNumbers.map((number) => {
        return (
          <li key={number} className="page-item">
            <a
              onClick={() => props.paginate(number)}
              href="#"
              className="page-link"
            >
              {number}
            </a>
          </li>
        );
      })}
    </nav>
  );
};

export default PaginationComponent;
