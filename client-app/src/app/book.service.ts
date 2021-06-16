import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  baseUrl="https://localhost:44361/api/books/";
  
  constructor(private http: HttpClient) { }

  addBook(book:any){
    return this.http.post(this.baseUrl,book);
  }
  updateBook( bookId:any, book:any){
    return this.http.put(this.baseUrl+bookId,book);
  }
  getbooks(){
    return this.http.get(this.baseUrl);
  }
  getBookById(bookId:any){
    return this.http.get(this.baseUrl+bookId);
  }
  deleteBook(bookId:any){
    return this.http.delete(this.baseUrl+bookId);
  }
}
