import { Component, OnInit, OnChanges, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit , OnChanges{

  @Input() totalItems:any;
  @Input() pageSize:number=10;
  currentPage:number=1;
  @Output()pageChanged = new EventEmitter();
  pages:any[];

  changePage(page:number){
    this.currentPage = page;
    this.pageChanged.emit(page);
  }

  next(){
    if(this.currentPage == this.pages.length)
        return;
    this.currentPage++;
    this.pageChanged.emit(this.currentPage);
   
  }
 previous(){
 if(this.currentPage == 1)
         return;
      this.currentPage--;
      this.pageChanged.emit(this.currentPage);
 }
  ngOnChanges(){
    this.currentPage = 1;
    var pageCount =  Math.ceil(this.totalItems /this.pageSize);
    this.pages = [];
    for(var i =1; i <= pageCount; i++){
      this.pages.push(i);
    }

  }



  constructor() { }

  ngOnInit() {
  }

}
