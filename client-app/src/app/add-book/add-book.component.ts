import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup } from '@angular/forms';
import { BookService } from '../book.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  bookForm : FormGroup;
  bookData: any;
  testId:any;
  btnPost="Save";
  btnUpdate="Update";
  headingPost="Add New Book";
  headingUpdate="Update Book";
  heading=this.headingPost;
  btnSave=this.btnPost;
  

  constructor(private formBuilder: FormBuilder, 
    private http: HttpClient, private service: BookService) { }

  ngOnInit(): void {
    this.bookForm=this.formBuilder.group({
      title:[""],
      description:[""],
      author:[""],
      totalPage:[]
    });
    this.getBooks();
   
  }

  // OnSubmit(): void{
  //   console.log(this.bookForm.value);
  // }

  // OnSubmit(): void{
  //  this.http.post("https://localhost:44361/api/books", this.bookForm.value).subscribe(data=>{
  //     console.log(data);     
  //  });
  // }

  OnSubmit(): void{
    if(this.testId && this.testId >0){
      this.updateBook();
      this.btnSave=this.btnPost;
      this.heading=this.headingPost;
      this.bookForm.reset();
      this.testId=0;
    }
    else{
      this.addBook();
      this.bookForm.reset();
    }    
   }

   addBook(){
     this.service.addBook(this.bookForm.value).subscribe(data=>{
      this.getBooks(); // For Refress Table
     });
   }

   getBooks(){
     this.service.getbooks().subscribe(data=>{
       this.bookData=data;
     });
   }

   edit(id:any){
      this.service.getBookById(id).subscribe(data=>{
        this.testId=id;
        this.bookForm.patchValue(data);
        this.btnSave=this.btnUpdate;
        this.heading=this.headingUpdate;
      })
   }

   updateBook(){
     const bookForUpdate={id:this.testId, title: this.bookForm.controls.title.value, 
      description:this.bookForm.controls.description.value, author: this.bookForm.controls.author.value,
      totalPage: this.bookForm.controls.totalPage.value}
     this.service.updateBook(bookForUpdate.id, bookForUpdate).subscribe(data=>{
      this.getBooks();
     });
   }

   delete(id:any){
     this.service.deleteBook(id).subscribe(data=>{
       this.getBooks();
     });
   }

}
