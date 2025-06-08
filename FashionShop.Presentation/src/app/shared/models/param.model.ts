export class Param{
    brandid? : number;
    subTypeId? :number;
    typeId?: number;
    pageIndex: number = 1;
    pageSize: number = 12;
    search?: string;
    gender?: string;
    sort: string = 'asc'
}