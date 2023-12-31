import { Component } from '@angular/core';
import { Member } from '../_models/member';
import { MembersService } from '../_services/members.service';
import { Pagination } from '../_models/pagination';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.scss']
})
export class ListsComponent {
  members: Member[] | undefined;
  predicate = 'liked';
  pageNumber = 1;
  pagesize = 5;
  pagination: Pagination | undefined;

  constructor(private memberService: MembersService) { }

  ngOnInit(): void {
    this.loadLikes();
  }

  loadLikes() {
    this.memberService.getLikes(this.predicate, this.pageNumber, this.pagesize).subscribe({
      next: response => {
        if (response && response.result) {
          this.members = response.result as any;
          this.pagination = response.pagination;
        }
      }
    });
  }
  pageChanged($event: PageChangedEvent) {
    if (this.pageNumber! == $event.page) {
      this.pageNumber = $event.page;
      this.loadLikes();
    }
  }
}
