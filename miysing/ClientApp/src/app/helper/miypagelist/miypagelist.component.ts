import { Component, Input, Output, EventEmitter, SimpleChanges } from '@angular/core';

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
  pageSize: number;
  option: Option = new Option();

  setPageSize(): void {
    let result = this.allData.length / this.maxItemOnePage;
    result = Number.isInteger(result) ? result : (result + 1);
    this.pageSize = parseInt(result.toString());
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
  setComputedProperty(): void {
    this.setPageSize();
  }
  get outputData(): any[] {
    return this.allData.slice((this.currentPage - 1) * this.maxItemOnePage, this.currentPage * this.maxItemOnePage);
  }

  getDisplayData(): void {
    this.displayData.emit(this.outputData);
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

  resetPage(): void {
    this.minPage = 1;
    this.currentPage = 1;
  }
  search(page: number): void {
    this.currentPage = page;
    const n = 2;
    if (this.currentPage > n) this.minPage = this.currentPage - n;
    else this.minPage = 1;
    if (this.currentPage == 1) this.minPage = 1;
    if (this.currentPage == this.pageSize) this.minPage = this.pageSize - this.maxPageButtonSize + 1 > 0 ? this.minPage = this.pageSize - this.maxPageButtonSize + 1 : 1;
    this.getDisplayData();
  }

  maxItemChanged() {
    if (this.maxItemOnePage < 1) this.maxItemOnePage = 1;
    this.setPageSize();
    this.getDisplayData();
  }

  ngOnChanges(changes: SimpleChanges) {
    let vm = this;
    setTimeout(() => {
      if (changes.allData && (!changes.allData.previousValue || !vm.isObjEqual(changes.allData.currentValue, changes.allData.previousValue))) {
        vm.resetPage();
        vm.setComputedProperty();
        vm.getDisplayData();
      }
    }, 0);
  }

  isObjEqual(o1, o2): boolean {
    var props1 = Object.getOwnPropertyNames(o1);
    var props2 = Object.getOwnPropertyNames(o2);
    if (props1.length != props2.length) {
      return false;
    }
    for (var i = 0, max = props1.length; i < max; i++) {
      var propName = props1[i];
      if (o1[propName] !== o2[propName]) {
        return false;
      }
    }
    return true;
  }

  setOption(option: Option) {
    this.option = option;
  }
}

class Option {
  itemSize: boolean = true
}
