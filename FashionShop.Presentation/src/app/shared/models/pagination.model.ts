export interface Pagination<T>{
    pageIndex: number
    pageSize: number
    totalItem: number
    data: T[]
}