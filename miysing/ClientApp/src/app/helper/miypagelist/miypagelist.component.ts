import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-miypagelist',
  templateUrl: './miypagelist.component.html'
})
export class MiypagelistComponent {
  @Input() allData: any[];
  @Output() displayData = new EventEmitter();

  maxPageButtonSize: number = 5;
  maxItemOnePage: number = 5;
  currentPage: number = 1;
  minPage: number = 1;
  get pageSize(): number {
    let result = this.allData.length / this.maxItemOnePage;
    result = Number.isInteger(result) ? result : (result + 1);
    return parseInt(result.toString());
  }
  get pageSizeArray(): number[] {
    //return Array.from({ length: this.maxPage }, (v, k) => k + 1);
    let result = [];
    for (var i = this.minPage; i <= this.maxPage; i++) {
      result.push(i);
    }
    return result;
  }
  get maxPage(): number {
    if (this.minPage + this.maxPageButtonSize - 1 > this.pageSize) return this.pageSize;
    else return this.minPage + this.maxPageButtonSize - 1;
  }

  getDisplayData(): void {
    this.displayData.emit(this.allData.slice((this.currentPage - 1) * this.maxItemOnePage, this.currentPage * this.maxItemOnePage));
  }

  next(): void {
    if (this.currentPage < this.pageSize) this.search(this.currentPage + 1);
  }
  mutiNext(): void {
    const n = 4;
    let changePage = n;
    if (this.pageSize - this.currentPage < n) changePage = this.pageSize - this.currentPage;
    this.search(this.currentPage + changePage);
  }
  previous(): void {
    if (this.currentPage > 1) this.search(this.currentPage - 1);
  }
  mutiPrevious(): void {
    const n = 4;
    let changePage = n;
    if (this.currentPage - 1 < n) changePage = this.currentPage - 1;
    this.search(this.currentPage - changePage);
  }

  search(page: number): void {
    this.currentPage = page;
    const n = 2;
    if (this.currentPage > n) this.minPage = this.currentPage - n;
    else this.minPage = 1;
    if (this.currentPage == 1) this.minPage = 1;
    if (this.currentPage == this.pageSize) this.minPage = this.pageSize - this.maxPageButtonSize + 1;
    this.getDisplayData();
  }

  ngOnInit(): void {
    let vm = this;
    setTimeout(() => {
      vm.getDisplayData();
    }, 500);
  }
}
