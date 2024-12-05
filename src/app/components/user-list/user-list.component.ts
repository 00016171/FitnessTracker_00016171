import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/users.service';
import { User } from '../../models/user.model';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  imports:[CommonModule]
})
export class UserListComponent implements OnInit {
  users: User[] = [];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getUsers().subscribe({
      next: (data) => (this.users = data),
      error: (error) => console.error('Failed to load users:', error),
    });
  }

  deleteUser(id: number): void {
    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteUser(id).subscribe({
        next: () => this.loadUsers(), // Refresh the list after deletion
        error: (error) =>
          console.error(`Failed to delete user with ID ${id}:`, error),
      });
    }
  }

  editUser(id: number): void {
    location.href = `/user-form/${id}`;
  }
}
