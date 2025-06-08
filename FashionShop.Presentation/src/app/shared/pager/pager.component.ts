import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrl: './pager.component.css'
})
export class PagerComponent implements OnChanges{
  @Input() itemPerPage!: number
  @Input() totalItem!: number
  @Input() pageIndex!: number
  totalPage:number = 0
  @Output() PageChanged = new EventEmitter<number>() 
  
  ngOnChanges(changes: SimpleChanges): void {
    this.totalPage = Math.ceil(this.totalItem / this.itemPerPage)
    if(this.pageIndex > this.totalPage)
      this.pageIndex = 1
  }

  getVisiblePages():(number | null)[]
  {
    const total = this.totalPage
    const current = this.pageIndex
    const pages: (number | null)[] =[]

    if(total<=7)
    {
      return Array.from({length:total},(_,i) => i + 1)
    }

    pages.push(1)
    if(current > 3)
    {
      pages.push(null)
    }

    for(let i = current - 1 ; i <= current + 1; i++)
    {
      if(i>1 && i< total)
      {
        pages.push(i)
      }
    }

    if(current <= total - 3)
    {
      pages.push(null)
    }

    pages.push(total)

    return pages
  }

  onPageChange(pageIndex: number)
  {
    if(pageIndex !== this.pageIndex)
    {
      this.pageIndex = pageIndex
      this.getVisiblePages()
      window.scrollTo({top:110,behavior:'smooth'})
      this.PageChanged.emit(pageIndex)
    }
  }

  onPreviousPageChange()
  {
    if(this.pageIndex !== 1)
    {
      this.pageIndex--
      this.getVisiblePages()
      window.scrollTo({top:110,behavior:'smooth'})
      this.PageChanged.emit(this.pageIndex)
    }
  }

  onForwardPageChange()
  {
    if(this.pageIndex !== this.totalPage)
    {
      this.pageIndex--
      this.getVisiblePages()
      window.scrollTo({top:110,behavior:'smooth'})
      this.PageChanged.emit(this.pageIndex)
    }
  }
}
