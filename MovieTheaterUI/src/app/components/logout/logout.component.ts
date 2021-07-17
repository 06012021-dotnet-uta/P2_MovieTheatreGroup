import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { User } from 'src/app/interfaces/user';
import { UserService } from 'src/app/services/user.service';
import { MessageService } from 'src/app/message.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {
  logoutUser : User = {
    userId: 0,
    username: '',
    passwd: '',
    firstName: '',
    lastName: '',
    roleId: 0
  };
  @Output() userevent = new EventEmitter<User>();


  constructor( private userService: UserService,
               private messageService : MessageService) { }

  ngOnInit(): void {
  }
  LogoutUser() : void {

    this.messageService.add(`before logout ${this.logoutUser.username}`);
    this.messageService.add(`before logout current user:  ${this.userService.authorizedUser?.username}`);
    this.userevent.emit(this.logoutUser);
    this.userService.AuthorizedUser(this.logoutUser);
    this.messageService.add("BYE BYE");
    this.messageService.add(`After logout current user:  ${this.userService.authorizedUser?.username}`);
    // // this.messageService.add(`after login ${this.currentUser.username}`);
    // this.authorizedUser = this.users?.find( user => user.username == this.currentUser.username
    //   && user.passwd == this.currentUser.passwd);
    // // this.messageService.add(`authorizedUser username:  ${this.authorizedUser?.username}`);

    // if(this.authorizedUser?.username != this.currentUser.username){
    //   this.messageService.add("wrong username or password");
    // }else {
    //   this.messageService.add(` Hi ${this.authorizedUser?.username} Welcome to The Theater Movie app`);
    //   this.userService.AuthorizedUser(this.authorizedUser);
    // }

  }

}
