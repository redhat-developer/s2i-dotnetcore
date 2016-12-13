package com.schoolbus.client.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonCreator;
import com.schoolbus.client.model.BusNotification;
import com.schoolbus.client.model.User;



import io.swagger.annotations.*;
import java.util.Objects;


public class UserNotifications   {
  
  private Integer id = null;
  private BusNotification busNotification = null;
  private User user = null;

  /**
   * Primary Key
   **/
  public UserNotifications id(Integer id) {
    this.id = id;
    return this;
  }

  
  @ApiModelProperty(example = "null", required = true, value = "Primary Key")
  @JsonProperty("Id")
  public Integer getId() {
    return id;
  }
  public void setId(Integer id) {
    this.id = id;
  }

  /**
   **/
  public UserNotifications busNotification(BusNotification busNotification) {
    this.busNotification = busNotification;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("BusNotification")
  public BusNotification getBusNotification() {
    return busNotification;
  }
  public void setBusNotification(BusNotification busNotification) {
    this.busNotification = busNotification;
  }

  /**
   **/
  public UserNotifications user(User user) {
    this.user = user;
    return this;
  }

  
  @ApiModelProperty(example = "null", value = "")
  @JsonProperty("User")
  public User getUser() {
    return user;
  }
  public void setUser(User user) {
    this.user = user;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    UserNotifications userNotifications = (UserNotifications) o;
    return Objects.equals(id, userNotifications.id) &&
        Objects.equals(busNotification, userNotifications.busNotification) &&
        Objects.equals(user, userNotifications.user);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, busNotification, user);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class UserNotifications {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    busNotification: ").append(toIndentedString(busNotification)).append("\n");
    sb.append("    user: ").append(toIndentedString(user)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }
}

